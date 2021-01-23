    public List<int> GenerateWeighedList(int[] list, float[] weight) {
        var weighedList = new List<int>();
         
        // Loop over weights
        for (var i = 0; i < weight.Length; i++) {
            var multiples = weight[i] * 100;
             
            // Loop over the list of items
            for (var j = 0; j < multiples; j++) {
                weighedList.push(list[i]);
            }
        }
         
        return weighedList;
    };
