    <!doctype html>
    @using System;
    @using System.Collections.Generic;
    @using System.Collections;
    @using System.Linq;
    @{
        var dictionary = new Dictionary<string, object>();
        dictionary.Add("fName", returnString100.FRSTNAME.Trim());
    
        Func<string, object> PrintOut = delegate(string toBePrinted)
        {
            object curValue;
            if (dictionary.TryGetValue(toBePrinted, out curValue))
                return curValue;
            return "";   
        };
    }
    <table>
        <tr>
            <td>First Name:</td><td>@PrintOut("fName").ToString()</td>
        </tr>
    </table>
