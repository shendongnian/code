        <%
                Dictionary<string, int> injuryList = ViewData["InjuryDictionary"] as Dictionary<string, int>;
                //var injuryList = ViewData["InjuryDictionary"] as Dictionary<string, int>;
            
        %>
               <%:injuryList.First().Key%>
               <%:injuryList.First().Value%>
 
