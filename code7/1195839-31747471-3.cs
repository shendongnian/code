    private async void btnx_Click(object sender, EventArgs e)
    {
      await bgWorkerX_DoWorkAsync();
    }
    
    private async void bgWorkerX_DoWorkAsync()
    {
        Dictionary<string, object> dictCfgOut = await GenerateConfigDictAsync();
        XGen.CreateX.aReadFile(inputPathXRAW.Text,  outputPathX.Text, dictCfgOut);
    }
    
    private Task<Dictionary<string, object>> GenerateConfigDictAsync()
        {
            return Task.Run(() => {
            Dictionary<string, object> ConfigDict = new Dictionary<string, object>();
    
            if (cbXAddOnus.Checked)
            {
                if (!MiscTools.ValidateX(txtInstX.Text, true))
                    return null;
            }
    
            ConfigDict.Add("Available Images", GenerateConfigImageArray());
            ConfigDict.Add("X SCSC Hot", (cbXAddSCSC.Checked) ? (bool)true : (bool)false);
            ConfigDict.Add("X Req Adj", (cbXAddAdjustment.Checked) ? (bool)true : (bool)false);
            ConfigDict.Add("X Items", (cbXAddX.Checked) ? (bool)true : (bool)false);
            ConfigDict.Add("X Use Something", (cbXAddX.Checked) ? (bool)true : (bool)false);
            ConfigDict.Add("X Somedata", (string)txtX.Text);
            ConfigDict.Add("X Use SAN", (cbX.Checked) ? (bool)true : (bool)false);
            ConfigDict.Add("X % Y", (int)sliderX.Value);
    
            return ConfigDict;
        });
    }
