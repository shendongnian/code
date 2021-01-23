    public static void SetStatusOfObject(IOrganizationService service, string entityName, Guid entityId, int state, int status)
        {
            SetStateRequest updateStatus = new SetStateRequest();
            updateStatus.EntityMoniker = new EntityReference(entityName, entityId);
            updateStatus.State = new OptionSetValue(state);
            updateStatus.Status = new OptionSetValue(status);
            service.Execute(updateStatus);
        }
