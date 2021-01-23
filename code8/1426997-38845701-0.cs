    @model IEnumerable<Contact>
    <script>
       var name = document.getElementById("nameBox").value;
       function nameBoxOperations(name) {
           @foreach (var names in @Model)
           {
               @:if (names.givenName == name)
               {
                   @:alert('name matched');
                   //OPERATIONS
               }
           }
       }
    </script>
