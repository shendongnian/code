    @using (@Html.BeginForm("GetList", "Home", FormMethod.Get))
    {
    if (ViewBag.Pro != null)
    {
    @Html.DropDownList("Pro", "Select Product")}
    }
     <br />
     <input type="submit" name="btnSub" id="btnSub" value="Submit" /> 
     }
     @{
     mvcEntity objEntity = new mvcEntity();
     int ProCode = 0;
     if (Request["Pro"] != null)
     {
        ProCode = int.Parse(Request["Pro"]);
        tblProduct pmd = objEntity.tblProduct.Where(x => x.ProductCode == ProCode).FirstOrDefault();
    <table border="1">
        <thead>
            <tr>
                <th>Product ID</th>
                <th>Product Code</th>
                <th>Product Name</th>
                
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>@pmd.ProductId</td>
                <td>@pmd.ProductCode</td>
                <td>@pmd.ProductName</td>
            </tr>
        </tbody>
    </table>
    }   
}
