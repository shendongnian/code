    if (item.IsComplete)
    {
       @:<strike>
    }
    @Html.DisplayFor(modelItem => item.TaskDetails)
    if (item.IsComplete)
    {
      @:</strike>
    }
