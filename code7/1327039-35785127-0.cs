    $.ajax({
                url: "ControllerClass/ControllerMethod",
                type: "POST",
                dataType: 'json',
                data: { Summary: globalVariable.summary},
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    DoSomethingNewWithThisresult(result)
                }
            })
    public class YourClass
    {
        public string Summary { get; set;}//// string type or whatever it is
    }
    public IActionResult ControllerMethod(YourClass result)
    {
         DoSomethingHereWithTheResult(result);       
    }
