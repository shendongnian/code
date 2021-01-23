    @{
       string serviceNotesJson = JsonConvert.SerializeObject(ViewBag.ServiceNotes);
       string serviceNameJson = JsonConvert.SerializeObject(ViewBag.ServiceName);
       string serviceIndexJson = JsonConvert.SerializeObject(ViewBag.ServiceIndex);
    }
    @section scripts 
    {
        <script>
            var ServiceNotes = @(Html.Raw(serviceNotesJson));  
            var ServiceName = @(Html.Raw(serviceNameJson));
            var ServiceIndex = @(Html.Raw(serviceIndexJson));
        </script>
    }
