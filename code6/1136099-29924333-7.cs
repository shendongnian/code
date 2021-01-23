    timer.Elapsed += ((source, e) =>
    {
        var INDEX = Form.ActiveForm.Controls.IndexOfKey("errorBox");
        Debug.WriteLine(Form.ActiveForm.Controls[INDEX]);
        //Invoke the instance of "Form" to process changes on the UI thread
        Form.Invoke((MethodInvoker)delegate
        {
            Form.ActiveForm.Controls[INDEX].Text = "";
        });
        Debug.WriteLine("2" + Form.ActiveForm.Controls[INDEX]);
    });
    timer.Enabled = true;
    timer.Start();
