    /// <summary>
    ///   Container for data that should be written to an Excel file
    /// </summary>
    public class ExcelData
    {    
      public Guid Id { get; set; }
      public List<Range> ExcelRanges { get; set; }
    }
  
    public class Range
    {
      public string Name { get; set; }
      public List<List<object>> Values { get; set; }
    }
    [HttpPost]
    [Route("Measures")]
    public Guid Measures(ExcelData excelData)
    {
     ...
    }
----
    function execute(site, filteredMeasures) {
    
        var excelRanges  = [
         { 
          'Name': 'additionalInvestmentEfficiency', 
          'Values': [[1,2],[3,4]] 
         },
         { 
          'Name': 'totalInvestment', 
          'Values': [[10,20],[30,40]]
         }
       ];
        var data = {
          'Id': site.siteId(),
          'ExcelRanges': excelRanges     
        };
    
        return $.ajax({
          url: routeConfig.exportMeasureDataByUrl,
          type: 'POST',
          contentType: 'application/json',
          processData: false,
          data: JSON.stringify(data),
          headers: appSecurity.getSecurityHeaders()
        }).done(function(downloadId) {
          window.location.href = routeConfig.exportMeasureDataByUrl + '?downloadId=' + downloadId;
        });
    
    
      }
