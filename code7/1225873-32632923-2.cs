    using System.Collections.Generic;
    using System.Web.Http;
    
    namespace WebApiOne.Controllers
    {
        public class Task
        {
            public int TaskID { get; set; }
            public int ProjectID { get; set; }
            public string ProjectName { get; set; }
            public string TaskName { get; set; }
            public string TaskStatus { get; set; }
        }
    
        public class TaskController : ApiController
        {
            // GET api/task
            public IEnumerable<Task> Get() {
                Task[] tasks = {
                    new Task {
                        TaskID = 1,
                        ProjectID = 1,
                        ProjectName = "ProjectOne",
                        TaskName = "FirstPage Development",
                        TaskStatus = "InProgress"
                    },
                    new Task {
                        TaskID = 2,
                        ProjectID = 1,
                        ProjectName = "ProjectOne",
                        TaskName = "Second Page Development",
                        TaskStatus = "Yet To Start"
    
                    }
                };
                return tasks;
            }
    
            // GET api/task/5
            public string Get(int id)
            {
                return "value";
            }
    
            // POST api/task
            public void Post ([FromBody]Task task)
            {
                //perform new Row Add to DB
                // task.TaskID will be 0 here
            }
    
            // PUT api/task/5
            public void Put (int id, [FromBody]Task task)
            {
                //perform Db Update
                // task.TaskID and id are identical
            }
    
            // DELETE api/task/5
            public void Delete (int id)
            {
                // Delete row in DB.
            }
        }
    }
