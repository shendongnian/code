    var result = clsFoldingObj.createFolding(1,'abhi',1,'empty', new Date());
    if(result.Status == 0){
        // result has an exception
        MessageBox.Show("Process Unsuccessful - "result.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
    }
    else{
        // Success 
        MessageBox.Show("Process Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
