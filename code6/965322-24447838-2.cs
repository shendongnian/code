    [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
        public static string checkUserNameAvail(string iuser)
        {
            try
            {
                iCalendarClass iC = new iCalendarClass();
                DataSet ds = iC.checkUserNameAvail(iuser);
                return (ds.GetXml());
            }
            catch
            {
                return null;
            }
        }
