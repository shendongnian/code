    public class User : Contact {
    }
    
    var contact = GetSomeContact();
    var user = contact as User;
    if (user != null) {
        // This is a user! Do some special handling
    }
