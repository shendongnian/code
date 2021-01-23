        // strip the domain
        var NT_WORLD = Convert.ToString(username.Contains("DOMAIN"));
        username = Regex.Replace(username, "DOMAIN", "");
        username = Regex.Replace(username, "\\\\", "");
        var first_initial = username[0];
        var last_initial = username[1];
        //The Ative directory structure is [first initial firstname][first inital lastname][badge number]
        var EIN = Regex.Replace(username, "[^0-9]", "");//get the badge number so we can query the badging database
        // check the employee database to see if this AD account matches something 
        var query = "SELECT BadgeNumber, FirstName, LastName,  DEPT_NUM, DEPT, TITLE, Supervisor " +
                         "FROM TABLE_WITH EMPLOYEE INFORMATION " +
                         "WHERE LEFT(FirstName, 1) = '" + first_initial + "' AND LEFT(LastName, 1) = '" + last_initial + "' AND BadgeNumber = '" + EIN + "' AND STATUS = 'Active' ";
