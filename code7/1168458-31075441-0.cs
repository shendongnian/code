    public OutArgument<List<xmlsStruct>> OutList { get; set; }
    //assuming that you will write some code in this method to parse the string and create a return var
    public List<xmlsStruct> getXMLData(string XMLResponse){ return dataList }
    protected override void Execute(CodeActivityContext context)
    {
       //you will need to get you xml string var from somewhere. Maybe an InArgument<string> ? if so use context.GetValue(InargumemntName)
       var  dataList = this.getXMLData("Your xml response data");
       context.SetValue(OutList, dataList);
    }
