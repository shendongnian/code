    public class ProgressTracker {
    	private static GlobalIdProvider = 0;
    	public int _id = ++GlobalIdProvider;
    	public int Id { get { return _id; } }
    	bool IsInProgress = false;
    	bool IsComplete = false;
    	float Progress;
    	public YourProgressObject Data;
    }
    
    public class GlobalStatic {
    	public static List<ProgressTracker> FooOperations = new List<ProgressTracker>();
    }
    
    public class SomeWebApiController {
    	[HttpGet]
    	[Authorize]
    	public HttpResponseMessage GetProgress(int Id) {
    		var query = (from a in GlobalStatic.FooOperations where a.Id==Id select a);
    		if(!query.Any()) {
    			return Request.CreateResponse(HttpStatusCode.NotFound, "No operation with this Id found.");
    		} else {
    			return Request.CreateResponse(HttpStatusCode.Ok, query.First());
    		}
    	}
    }
    
    // this is javascript
    // ... Your code until it starts the process.
    // You'll have to get the ProgressTracker Id from the server somehow.
    var InProgress = true; 
    window.setTimeout(function(e) {
    	var xmlhttp = new XMLHttpRequest();
    	var url = "<myHostSomething>/SomeWebApiController/GetProgress?Id="+theId;
    	xmlhttp.setRequestHeader("Authentication","bearer "+localStorage.getItem("access_token"));
    
    	xmlhttp.onreadystatechange = function() {
    		if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
    			var data = JSON.parse(xmlhttp.responseText);
    			updateProgressBar(data);
    		}
    	}
    	xmlhttp.open("GET", url, true);
    	xmlhttp.send();
    
    	function updateProgressBar(data) {
    		document.getElementById("myProgressText").innerHTML = data.Progress;
    	}
    }, 3000);
