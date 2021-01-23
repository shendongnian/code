    private void button1_Click(object sender, System.EventArgs e)
    {
        // Reset the batch steps
        transaction1.BatchSteps.Clear();
      
        // fill new steps
        transaction1.ExecutionMode =    ERPConnect.Utils.TransactionDialogMode.ShowOnlyErrors;
        transaction1.TCode = "MMBE";
        transaction1.AddStepSetNewDynpro("RMMMBEST","1000");
        transaction1.AddStepSetOKCode("ONLI");
        transaction1.AddStepSetCursor("MS_WERKS-LOW");
        transaction1.AddStepSetField("MS_MATNR-LOW",textBox1.Text);
        transaction1.AddStepSetField("MS_WERKS-LOW",textBox2.Text);
      
        // connect to SAP
        r3Connection1.UseGui = true;
      
       R3Connection r3Connection1= new R3Connection("SAPServer",00,"SAPUser","Password","EN","800");
         r3Connection1.Open(false);
         // Run
         transaction1.Execut e();
      
    }
