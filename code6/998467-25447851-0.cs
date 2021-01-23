    public void Main()
    {
        var obj = new ClassWithNotifier();
        obj.OnPropertyChanged += ObjectPropertyChanged;
        DoSomethingWithObj(obj);
    }
    private void ObjectPropertyChanged(string propertyName)
    {
        switch (propertyName) {
            case ClassWithNotifier.CustomerIdPropertyName:
                // If the constant changes this will still work
                break;
            case "SomeOtherPropertyName":
                // If you change the property string that is passed here from 
                // your class ClassWithNotifier then this will now break
                break;
        }
    }
