        [WebMethod]
        public static static SendPerson()
        {
            JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            return TheSerializer.Serialize(new Person("Jhon Snow", DateTime.Now));
        }
