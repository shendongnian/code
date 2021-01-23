    //ValidationProcess For an entity
        public Collection<ValidationIssue> ValidationProcess(string ModelName, string verName, string EntityName, string memCode)
        {
            //Instantiate all of request and response objects
            ValidationProcessRequest Request = new ValidationProcessRequest();
            ValidationProcessResponse Response = new ValidationProcessResponse();
            //Instantiate the Criteria and Options objects
            Request.ValidationProcessCriteria = new ValidationProcessCriteria();
            Request.ValidationProcessOptions = new ValidationProcessOptions();
            //Set Model and Version Identifiers - these will be required in all instances
            Request.ValidationProcessCriteria.ModelId = new Identifier { Name = ModelName };
            Request.ValidationProcessCriteria.VersionId = new Identifier { Name = verName };
            Request.ValidationProcessCriteria.EntityId = new Identifier { Name = EntityName };
            Request.ValidationProcessCriteria.Members = new Collection<MemberIdentifier>();
            Request.ValidationProcessCriteria.Members.Add(new MemberIdentifier { Code = memCode });
            //Options can return validation results or trigger the commit of a version (when validation is already successful)
            Request.ValidationProcessOptions.ReturnValidationResults = true;
            Response = mds_Proxy.ValidationProcess(Request);
            return Response.ValidationIssueList;
        }
