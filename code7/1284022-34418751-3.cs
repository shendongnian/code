    Imports NewtonExtensions
    Imports Newtonsoft.Json.Linq
    
    Public Class Form1
    
        Private Sub Button1_Click(sender As Object, e As EventArgs) _
            Handles Button1.Click
    
            Dim jsonString As String =
                <json>
    {
        "ADDRESS_MAP":{
    
            "ADDRESS_LOCATION":{
                "type":"separator",
                "name":"Address",
                "value":"",
                "FieldID":40
            },
            "LOCATION":{
                "type":"locations",
                "name":"Location",
                "keyword":{
                    "1":"LOCATION1"
                },
                "value":{
                    "1":"United States"
                },
                "FieldID":41
            },
            "FLOOR_NUMBER":{
                "type":"number",
                "name":"Floor Number",
                "value":"0",
                "FieldID":55
            },
            "self":{
                "id":"2",
                "name":"Address Map"
            }
        }
    }                
                </json>.Value
    
    
            Dim results As JObject = JObject.Parse(jsonString)
    
            Console.WriteLine("Example 1")
            For Each item As KeyValuePair(Of String, JToken) In results
                Console.WriteLine(item.Key)
                Dim test = item.Value.AllChildren
                For Each subItem In test
                    Console.WriteLine(subItem)
                    Console.WriteLine()
                Next
            Next
            Console.WriteLine(New String("-"c, 50))
            Console.WriteLine("Example 2")
            results.Cast(Of KeyValuePair(Of String, JToken)) _
                .ToList.ForEach(
                    Sub(v)
                        Console.WriteLine(v.Key)
                        Console.WriteLine(v.Value)
                    End Sub)
    
    
        End Sub
    End Class
