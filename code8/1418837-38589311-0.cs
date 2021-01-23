        var class_name = new string[] {}; // I changed this line just to comply with coding best practices
    
        @foreach (string items in str_array) 
                                // str_array I am getting like [0] = 1
                                //                             [1] = 2 
            {
                if (items.ToString() == class_id.ToString())
                {
                    class_name = new string[] { "visited" };
                    break;
                }
                else
                {
                    class_name = new string[] { "NotVisited" };   
                }
            }
    
        @Html.ActionLink("test", "R_Class", "R_Class", null, new { @class = string.Format("{0}", class_name), onclick = "return false;" }) 
