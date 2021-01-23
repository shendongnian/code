    private void btnFindTest_Click(object sender, EventArgs e)
    {
        Test found = null;
        string name = txtName.Text;
        if (submittedTest.TryGetValue(name, out found))
        {
            submittedTest.Remove(name);
            outForChecking [name] = found;
            //Tester to validate how many items are left in the submittedTest que
            Console.WriteLine("{0}", submittedTest.Count);
        }
    } 
