    class WorkflowHandler 
    {
        private IWorkflowServiceFactory _wfsfactory
        public WorkflowHandler(IWorkflowServiceFactory workflowservicefactory)
        {
            _wfsfactory = workflowservicefactory;
        }
        public bool Handle(IWorklfowableEntity entity)
        {
            var svc = _wfsfactory.GetServiceByEntity(entity);
            var context = new WfContext();
            svc.FillContext(context, entity);
            //handle evaluate etc.
        }
    }
