    foreach (var item in Model)
    {
        <p>@item.Prod.MSP</p>
        <p>@{int? c = 0;if (item.Count == null) { c = 0; } else { c = item.Count; }}@c</p>
    }
