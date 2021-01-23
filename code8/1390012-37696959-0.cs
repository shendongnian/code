    public class Person {  public string Name { get; set; } }
    public void DataExport(Person item) {
    }
    var postData =  '{ "Name": "Some Person" }';
    $.ajax(url, postData);
