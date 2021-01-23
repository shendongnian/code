    try
    {
       var result = await Task.Run(() => GetResult());
       // Update UI: success.
       // Use the result.
       listView.DataSource = result;
       listView.DataBind();
    }
    catch (Exception ex)
    {
       // Update UI: fail.
       // Use the exception.
    }
