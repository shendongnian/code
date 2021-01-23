    foreach (object request in i.ToString())
    {
        Label userName = new Label();
        Button accept = new Button();
        Button reject = new Button();
        int idRequest = Convert.ToInt32(dr["IDRequest"]);
        userName.Tag = idRequest;
        accept.Tag = idRequest;
        reject.Tag = idRequest;
        ....
