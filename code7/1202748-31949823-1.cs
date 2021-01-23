    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebMatrix.WebData;
    using System.Data.Entity;
    using ITFort.TestWeb.Models.DBFirst.Authorization;
    namespace ITFort.TestWeb.Filters
    {
        public class TestWebExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            using (TestWebAuthorizationEntities db = new TestWebAuthorizationEntities())
            {
                ExceptionDatabaseTable exception = new ExceptionDatabaseTable;
                exception.UserId = WebSecurity.CurrentUserId;
                exception.Controller = filterContext.RouteData.Values["controller"].ToString();
                exception.Action = filterContext.RouteData.Values["action"].ToString();
                exception.Message = filterContext.Exception.Message;
                exception.StackTrace = filterContext.Exception.StackTrace;
                exception.ErrorDateTime = DateTime.Now;
                db.Entry(exception).State = EntityState.Added;
                db.SaveChanges();
            }
        }
    }
    }
