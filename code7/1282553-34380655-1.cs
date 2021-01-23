    @section scripts {
       <script type="text/javascript">
        var czech_republic = {};
        window.selectedRegions = [];
        czech_republic.regions = {
            @Html.Raw(string.Join(", ", regions.Select(r => string.Format("\"{0}\": \"{1}\"", r.RaphaelId, r.RaphaelCoordinates))))
        };
    </script>
    @section asyncScripts {
        @Scripts.RenderFormat("async(\"{0}\");", "~/bundles/raphael");
    }
