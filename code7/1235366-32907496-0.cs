            string plainText1 = "Hello Amit";
            string plainText2 = "Hello Amit";
            Helper helper = new Helper();
    
    	    helper.GenerateIV();
            helper.GenerateKey();
            string encryptedData1 = helper.EncryptString(plainText1);
            string encryptedData2 = helper.EncryptString(plainText2);
            string getBackText = helper.DecryptString(encryptedData1);
            Console.WriteLine(getBackText);
            Console.ReadLine();
