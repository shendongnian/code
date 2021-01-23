     using (Session session = new Session())
     {
        // Connect
        session.Open(sessionOptions);
        return session;
     } //<-------------------- SESSION DISPOSED HERE!!
