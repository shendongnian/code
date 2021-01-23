    using Microsoft.TeamFoundation.Core.WebApi;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.Common;
    public void CreateWebHookBuildSubscription( string teamProject,string buildDefinitionName,string eventType = "build.complete",string status = "Succeeded",string apiVersion = "1.0" )
        {
            if (ConfigAccessBase.GetConfigBool( "EnableContinuousIntegration" ))
            {
                try
                {
                    VssConnection connection = new VssConnection( _tfsCollectionBaseUrl, new VssCredentials( true ) );
                    ProjectHttpClient pClient = connection.GetClient<ProjectHttpClient>();
                    TeamProjectReference project = pClient.GetProject( teamProject, false, false, null ).Result;
                    RestRequest checkSubsRequest = new RestRequest( "_apis/hooks/subscriptions/?api-version=" + apiVersion, Method.GET );
                    checkSubsRequest.UseDefaultCredentials = true;
                    checkSubsRequest.RequestFormat = DataFormat.Json;
                    var checkSubResponse = tfsRestClient.Execute( checkSubsRequest );
                    TFSListSubscriptionsResponse listSubResponse = JsonConvert.DeserializeObject<TFSListSubscriptionsResponse>( checkSubResponse.Content );
                    if (checkSubResponse.StatusCode != HttpStatusCode.OK)
                    {
                        WriteLogEntry( checkSubResponse, EventTypes.Errors, "Error in TFSWebHook.CreateWebHookBuildSubscription when calling TFS to get existing subscription list: " + checkSubResponse.ErrorMessage + " " + checkSubResponse.ErrorException.ToString() );
                        return;
                    }
                    string notificationUrl = ConfigAccessBase.GetConfig( "ServiceBaseUrl" ) + @"/Remoting.asmx/ReceieveTFSBuildSuccessNotification";
                    if (listSubResponse.count == 0 || !listSubResponse.value.Any( x =>
                        x.publisherInputs.buildStatus.ToLower().Equals( status.ToLower() )
                        && x.eventType.ToLower().Equals( eventType.ToLower() )
                        && x.publisherInputs.definitionName.ToLower().Equals( buildDefinitionName.ToLower() )
                        && x.publisherInputs.projectId.Equals( project.Id.ToString() )
                        && x.consumerInputs.url.ToLower().Equals( notificationUrl.ToLower() ) ))
                    {
                        WriteLogEntry( checkSubResponse, EventTypes.Informational, "TFSWebHook.CreateWebHookBuildSubscription creating a new build notification web hook subscription in TFS: TeamProject: " + project.Name + " Definition: " + buildDefinitionName + " Status: " + status );
                        SubscribeToTFSBuildRequest request = new SubscribeToTFSBuildRequest()
                        {
                            publisherId = "tfs",
                            eventType = eventType,
                            consumerId = "webHooks",
                            consumerActionId = "httpRequest",
                            resourceVersion = "1.0",
                            publisherInputs = new TFS.WebApi.Lib.PublisherInputs()
                            {
                                buildStatus = status,
                                definitionName = buildDefinitionName,
                                projectId = project.Id.ToString()
                            },
                            consumerInputs = new TFS.WebApi.Lib.ConsumerInputs
                            {
                                url = notificationUrl
                            }
                        };
                        RestRequest createSubReq = new RestRequest( "_apis/hooks/subscriptions?api-version=" + apiVersion, Method.POST );
                        createSubReq.UseDefaultCredentials = true;
                        createSubReq.RequestFormat = DataFormat.Json;
                        createSubReq.AddJsonBody( request );
                        var createSubResponse = tfsRestClient.Execute( createSubReq );
                        if (createSubResponse.StatusCode != HttpStatusCode.OK)
                        {
                            WriteLogEntry( createSubResponse, EventTypes.Errors, "Error in TFSWebHook.CreateWebHookBuildSubscription when calling TFS to create a subscription: " + createSubResponse.ErrorMessage + " " + createSubResponse.ErrorException.ToString() );
                            return;
                        }
                        //dont actually need any data
                        //SubscribeToTFSBuildResponse subscribeResponse = JsonConvert.DeserializeObject<SubscribeToTFSBuildResponse>( createSubResponse.Content );
                    }
                }
                catch (Exception ex)
                {
                    WriteLogException( ex );
                }
            }     
        }
