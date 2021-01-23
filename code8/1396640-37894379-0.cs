        // Aircraft
        Response.Output.Write("<h3>Aircrafts</h3>");
        Response.Output.Write("<ul>");
        foreach (var aircraft in result.Trips.Data.Aircraft)
        {
            Response.Output.Write("<li>" + aircraft.Name + " " + aircraft.Code + "</li>");
        }
        Response.Output.Write("</ul>");
