        public static void InvokeSubmitFeed(MarketplaceWebService.MarketplaceWebService service, SubmitFeedRequest request, List<string> OrderTrackingInfoIds)
        {
            try
            {
                SubmitFeedResponse response = service.SubmitFeed(request);
                Console.WriteLine("        SubmitFeedResponse");
                if (response.IsSetSubmitFeedResult())
                {
                    Console.WriteLine("            SubmitFeedResult");
                    Util.log("            SubmitFeedResult");
                    SubmitFeedResult submitFeedResult = response.SubmitFeedResult;
                    if (submitFeedResult.IsSetFeedSubmissionInfo())
                    {
                        Console.WriteLine("                FeedSubmissionInfo");
                        Util.log("            FeedSubmissionInfo");
                        FeedSubmissionInfo feedSubmissionInfo = submitFeedResult.FeedSubmissionInfo;
                        if (feedSubmissionInfo.IsSetFeedSubmissionId())
                        {
                            Console.WriteLine("                    FeedSubmissionId");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.FeedSubmissionId);
                            Console.WriteLine(" Total Updates :" + result.ToString());
                            Util.log("Total Updates :" + result.ToString());
                            Util.log("                      FeedSubmissionId");
                            Util.log("                        " + feedSubmissionInfo.FeedSubmissionId);
                        }
                        if (feedSubmissionInfo.IsSetFeedType())
                        {
                            Console.WriteLine("                    FeedType");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.FeedType);
                            Util.log("                      FeedType");
                            Util.log("                        " + feedSubmissionInfo.FeedType);
                        }
                        if (feedSubmissionInfo.IsSetSubmittedDate())
                        {
                            Console.WriteLine("                    SubmittedDate");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.SubmittedDate);
                            Util.log("                      SubmittedDate");
                            Util.log("                        " + feedSubmissionInfo.SubmittedDate);
                        }
                        if (feedSubmissionInfo.IsSetFeedProcessingStatus())
                        {
                            Console.WriteLine("                    FeedProcessingStatus");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.FeedProcessingStatus);
                            Util.log("                      FeedProcessingStatus");
                            Util.log("                        " + feedSubmissionInfo.FeedProcessingStatus);
                        }
                        if (feedSubmissionInfo.IsSetStartedProcessingDate())
                        {
                            Console.WriteLine("                    StartedProcessingDate");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.StartedProcessingDate);
                            Util.log("                      StartedProcessingDate");
                            Util.log("                        " + feedSubmissionInfo.StartedProcessingDate);
                        }
                        if (feedSubmissionInfo.IsSetCompletedProcessingDate())
                        {
                            Console.WriteLine("                    CompletedProcessingDate");
                            Console.WriteLine("                        {0}", feedSubmissionInfo.CompletedProcessingDate);
                            Util.log("                      CompletedProcessingDate");
                            Util.log("                        " + feedSubmissionInfo.CompletedProcessingDate);
                        }
                    }
                }
                if (response.IsSetResponseMetadata())
                {
                    Console.WriteLine("            ResponseMetadata");
                    MarketplaceWebService.Model.ResponseMetadata responseMetadata = response.ResponseMetadata;
                    if (responseMetadata.IsSetRequestId())
                    {
                        Console.WriteLine("                RequestId");
                        Console.WriteLine("                    {0}", responseMetadata.RequestId);
                        Util.log("                          RequestId");
                        Util.log("                        " + responseMetadata.RequestId);
                    }
                }
                Console.WriteLine("            ResponseHeaderMetadata");
                Console.WriteLine("                RequestId");
                Console.WriteLine("                    " + response.ResponseHeaderMetadata.RequestId);
                Console.WriteLine("                ResponseContext");
                Console.WriteLine("                    " + response.ResponseHeaderMetadata.ResponseContext);
                Console.WriteLine("                Timestamp");
                Console.WriteLine("                    " + response.ResponseHeaderMetadata.Timestamp);
            }
            catch (MarketplaceWebServiceException ex)
            {
                Console.WriteLine("Caught Exception: " + ex.Message);
                Console.WriteLine("Response Status Code: " + ex.StatusCode);
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine("Error Type: " + ex.ErrorType);
                Console.WriteLine("Request ID: " + ex.RequestId);
                Console.WriteLine("XML: " + ex.XML);
                Console.WriteLine("ResponseHeaderMetadata: " + ex.ResponseHeaderMetadata);
            }
        }
