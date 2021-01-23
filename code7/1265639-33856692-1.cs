    <script>
        function check() {
            var Not = false;
            //Doing something...
            if (Not) {
                window["@ViewBag.IsTrue"] = false;
            }
            else{
                window["@ViewBag.IsTrue"] = true;
            }
    </script>
