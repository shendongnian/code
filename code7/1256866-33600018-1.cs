    public void Blargh() {
        Foo foo = new Foo();
        FieldInfo aField = foo.GetType().GetField("_aField");
        String aFieldValue = aField.GetValue( foo );
        Type[] nestedTypes = foo.GetType().GetNestedTypes();
        Type aNestedClass = nestedTypes.Single( t => t.Name == "ANestedClass" );
    }
