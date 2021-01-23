    private void button1_Click(object sender, EventArgs e)
    {
    
        test test1, test2, test3;
    
        test1 = new test { ID="1", Name ="abc"};
        test1.Details = new Details { duration = "1", starttime = "9.00", endtime = "12.00" };
        test1.Remark = new Remark { IsRemarkVisible = true, RemarkText = "remark1" };
        test1.Tags = new Tags();
        test1.Tags.TagLocation = new TagLocation[] 
        { 
             new TagLocation{ Id = "1", TagText = "tag1" },
             new TagLocation{ Id = "2", TagText = "tag2" } 
        }; 
    
        test2 = new test { ID = "1", Name = "abc" };
        test2.Details = new Details { duration = "1", starttime = "9.00", endtime = "12.00" };
        test2.Remark = new Remark { IsRemarkVisible = true, RemarkText = "remark2" };
        test2.Tags = new Tags();
        test2.Tags.TagLocation = new TagLocation[] 
        { 
             new TagLocation{ Id = "1", TagText = "tag1" },
             new TagLocation{ Id = "2", TagText = "tag2" } 
        }; 
    
        test3 = new test { ID = "1", Name = "abc" };
        test3.Details = new Details { duration = "1", starttime = "9.00", endtime = "12.00" };
        test3.Remark = new Remark { IsRemarkVisible = true, RemarkText = "remark2" };
        test3.Tags = new Tags();
        test3.Tags.TagLocation = new TagLocation[] 
        { 
             new TagLocation{ Id = "1", TagText = "tag1" },
             new TagLocation{ Id = "2", TagText = "tag2" } 
        }; 
    
        MessageBox.Show("test1.Equals(test2) ... " + test1.Equals(test2).ToString());   // shows true
        MessageBox.Show("test2.Equals(test3) ... " + test2.Equals(test3).ToString());   // shows true
    }
