           if(string.IsNullOrEmpty(emailList))
            {
                emailList = DropDownList1.Text;
            }
            else
            {
                var tempEailList = emailList.Split(',').ToList();
                tempEailList.Add(DropDownList1.Text);
                emailList = string.Join(",", tempEailList);
            }
