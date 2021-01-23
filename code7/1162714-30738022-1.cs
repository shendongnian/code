        [CustomAction("Test")]
        public static ActionResult Test(Session session)
        {
            string dir = session.CustomActionData["Arg1"];
            session.Log("DIRECTORY equals " + dir);
            if (Directory.Exists(dir))
                session.Log("Success");
            return ActionResult.Success;
        }
