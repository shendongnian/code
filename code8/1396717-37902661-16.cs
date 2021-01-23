    Double ComputePartialSum(Int32 startIndex, Int32 count, Double step) {
      var vectorSize = Vector<Double>.Count;
      var remainder = count%vectorSize;
      var endIndex = startIndex + count - remainder;
      var partialSumVector = Vector<Double>.Zero;
      var iVector = new Vector<Double>(Enumerable.Range(startIndex, vectorSize).Select(i => (Double) i).ToArray());
      var loopIncrementVector = new Vector<Double>(Enumerable.Repeat((Double) vectorSize, vectorSize).ToArray());
      var point5Vector = new Vector<Double>(Enumerable.Repeat(0.5D, vectorSize).ToArray());
      var stepVector = new Vector<Double>(Enumerable.Repeat(step, vectorSize).ToArray());
      var fourVector = new Vector<Double>(Enumerable.Repeat(4D, vectorSize).ToArray());
      for (var i = startIndex; i < endIndex; i += vectorSize) {
        var xVector = Vector.Multiply(Vector.Subtract(iVector, point5Vector), stepVector);
        partialSumVector = Vector.Add(
          partialSumVector,
          Vector.Divide(
            fourVector,
            Vector.Add(Vector<Double>.One, Vector.Multiply(xVector, xVector))
          )
        );
        iVector = Vector.Add(iVector, loopIncrementVector);
      }
      var partialSumElements = new Double[vectorSize];
      partialSumVector.CopyTo(partialSumElements);
      var partialSum = partialSumElements.Sum();
      for (var i = endIndex; i < startIndex + count; i += 1) {
        var x = (i - 0.5D)*step;
        partialSum += 4D/(1D + x*x);
      }
      return partialSum;
    }
