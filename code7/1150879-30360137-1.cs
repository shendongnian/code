    string testString = maskedTextBox1.Text;
    int numberTest;
    if(int.TryParse(testString, out numberTest)
    {
          NCInterface.ConstCodeAdd(numberTest, true); 
    }
