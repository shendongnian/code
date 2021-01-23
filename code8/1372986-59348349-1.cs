            string transientDocumentId = "";
            string adobesignDocKey = "";
            string baseURI = "";
            var apiInstanceBase = new BaseUrisApi();
            var authorization = "Bearer " + apiKey;   //Example as Integration Key, see adobesign docs For OAuth.
            try
            {
                //___________________GET BASEURI ADOBE SIGN_________________________
                BaseUriInfo resultBase = apiInstanceBase.GetBaseUris(authorization);
                baseURI = resultBase.ApiAccessPoint; //return base uri
                //___________________UPLOAD YOUR PDF THEN REF ADOBE SIGN_________________________
                var apiInstanceFileUpload = new TransientDocumentsApi(baseURI + "api/rest/v6/");
                TransientDocumentResponse resultTransientID = apiInstanceFileUpload.CreateTransientDocument(authorization, File.OpenRead([ENTER YOUR LOCAL FILE PATH]), null, null, _filename, null);
                if (!String.IsNullOrEmpty(resultTransientID.TransientDocumentId))
                {
                    transientDocumentId = resultTransientID.TransientDocumentId; //returns the transient doc id to use below as reference                    
                }
                var apiInstance = new AgreementsApi(baseURI + "api/rest/v6/");
                //___________________CREATE ADOBE SIGN_________________________
                var agreementId = "";  // string | The agreement identifier, as returned by the agreement creation API or retrieved from the API to fetch agreements.
                var agreementInfo = new AgreementCreationInfo();                
                //transientDocument, libraryDocument or a URL (note the full namespace/conflicts with System.IO
                List<IO.Swagger.model.agreements.FileInfo> useFile = new List<IO.Swagger.model.agreements.FileInfo>();
                useFile.Add(new IO.Swagger.model.agreements.FileInfo { TransientDocumentId = transientDocumentId });
                agreementInfo.FileInfos = useFile;
                //Add Email To Send To:
                List<ParticipantSetMemberInfo> partSigners = new List<ParticipantSetMemberInfo>();
                partSigners.Add( new ParticipantSetMemberInfo { Email = "[ENTER VALID EMAIL SIGNER]", SecurityOption=null });
                
                //Add Signer To Participant
                List<ParticipantSetInfo> partSetInfo = new List<ParticipantSetInfo>();
                partSetInfo.Add(new ParticipantSetInfo { Name = "signer1", MemberInfos = partSigners, Role = ParticipantSetInfo.RoleEnum.SIGNER, Order=1, Label="" });
                agreementInfo.ParticipantSetsInfo = partSetInfo;
                agreementInfo.SignatureType = AgreementCreationInfo.SignatureTypeEnum.ESIGN;
                agreementInfo.Name = "Example Esign For API";
                agreementInfo.Message = "Some sample Message To Use Signing";
                agreementInfo.State = AgreementCreationInfo.StateEnum.INPROCESS;
                
                AgreementCreationResponse result = apiInstance.CreateAgreement(authorization, agreementInfo, null, null);
                adobesignDocKey = result.Id; //returns the document Id to reference later to get status/info on GET                
            }
            catch (Exception ex) 
            {
                //Capture and write errors to debug or display to user 
                System.Diagnostics.Debug.Write(ex.Message.ToString());
            }
