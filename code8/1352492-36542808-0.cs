    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using WebApplication6.Models;
    
    namespace WebApplication6.Controllers
    {
        public class ManageStudentInforAPIController : ApiController
        {
            private SchoolManagementEntities db = new SchoolManagementEntities();
    
            // GET: api/ManageStudentsInfoAPI
            [Route("api/MyApi")]
            public IQueryable<Student> Get()
            {
                return db.Students;
            }
        }
    }
