    @{
        var list = new List<TagItem>() {
            new TagItem() { TagName = "1" },
            new TagItem() { TagName = "2" },
            new TagItem() { TagName = "3" },
            new TagItem() { TagName = "4" },
            new TagItem() { TagName = "5" },
            new TagItem() { TagName = "6" },
            new TagItem() { TagName = "7" },
            new TagItem() { TagName = "8" }
        };
    
        var onlynames = list.Select(x => x.TagName);
    }
    
    @section Scripts {
        <script>
            var json = @Html.Raw(Json.Encode(list));
            var json1 = @Html.Raw(Json.Encode(onlynames));
        </script>
    }
