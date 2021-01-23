    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
    public class Service_Response
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public Service_Response()
        {
        }
        public Service_Response(string msg)
        {
            this.Message = msg;
            this.Data = null;
        }
        public Service_Response(string msg, dynamic obj)
        {
            this.Message = msg;
            this.Data = obj;
        }
        public Service_Response(string msg, object obj, Type obj_type)
        {
            this.Message = msg;
            this.Data = Convert.ChangeType(obj, obj_type);
        }
    }
