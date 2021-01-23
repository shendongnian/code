    catch (Exception err)
    { //rather its displaying these messages.
         Debug.WriteLine(err.Message);
         textBox1.Text = "Error reading names";
         textBox2.Text = err.Message;
    }
