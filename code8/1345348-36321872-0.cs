    int[,] results ={//Each number is a scorer's score
                          { 4, 7, 9, 3, 8, 6},//competitor 1
                          { 4, 8, 6, 4, 8, 5},//competitor 2
                            { 2, 1, 10, 10, 10, 10}
                         };
    var max = Enumerable.Range(0, results.GetLength(0))
        .Max(i => Enumerable.Range(0, results.GetLength(1)).Sum(j => results[i,j]));
    var bestScorersIds = Enumerable.Range(0, results.GetLength(0))
        .Where(i => Enumerable.Range(0, results.GetLength(1)).Sum(j => results[i, j]) == max)
        .ToList();
