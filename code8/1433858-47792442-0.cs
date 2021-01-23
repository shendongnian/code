    using (Stitcher stitcher = new Stitcher(false))
    {
        using (VectorOfMat vm = new VectorOfMat())
        {
        Mat result = new Mat();
        vm.Push(sourceImages);
        stitcher.Stitch(vm, result);
        resultImageBox.Image = result; //Display the result
        }
    }
