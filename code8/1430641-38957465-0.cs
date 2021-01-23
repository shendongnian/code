    while (r = GetNExtRecordFromMySQL())
    {
        Foo f = new Foo(r);
        f.DecryptedField1 = Decrypt(f.Feild1);
        f.DecryptedField2 = Decrypt(f.Field2);
        .
        .
        .
    }
    // more code
    dgv1.Columns[0].Name = "Field1";
    dgv1.Columns[0].DataPropertyName = "DecryptedField1";
    dgv1.Columns[1].Name = "Field2";
    dgv1.Columns[1].DataPropertyName = "DecryptedField2";
