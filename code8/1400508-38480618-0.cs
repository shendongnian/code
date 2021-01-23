        private void SaveAssignmentData(Guid id, DateTime start, DateTime finish, Config config)
        {  
            //start = DateTime.Today.AddHours(8);
            //finish = start.AddHours(10); //from 8am to 6pm
            
            var ctx = new Connection().ProjectOnline(config.SpOnlineSite, config.SpOnlineUsuario, config.SpOnlineSenha); //simple method to get the current context
            var resources = ctx.EnterpriseResources;
            ctx.Load(resources);
            ctx.ExecuteQuery();
            var resource = ctx.EnterpriseResources.FirstOrDefault(i => i.Email == "user@domain.com");
            if (resource == null) throw new Exception("Resource not found.");
            ctx.Load(resource, p => p.Assignments);
            ctx.ExecuteQuery();
            var timePhase = resource.Assignments.GetTimePhase(start, finish);
            ctx.Load(timePhase, p => p.Assignments);
            ctx.ExecuteQuery();
            var statusAssignment = timePhase.Assignments.FirstOrDefault(i => i.Id == id);
            if (statusAssignment != null)
            {
                statusAssignment.ActualWork = "6h";
                statusAssignment.SubmitStatusUpdates("through csom");
                ctx.ExecuteQuery();
            }
        }
