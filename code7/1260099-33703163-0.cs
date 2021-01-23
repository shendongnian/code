    int Resolution = 512;
    CudaContext ctx = new CudaContext(0);
    CudaKernel cuKernel = ctx.LoadKernel("kernel.ptx", "cu_ArrayInversion");
    			
    //float2 or cuFloatComplex
    float2[] fData = new float2[Resolution * Resolution];
    float2[] result = new float2[Resolution * Resolution];
    CudaDeviceVariable<float2> devData = new CudaDeviceVariable<float2>(Resolution * Resolution);
    CudaDeviceVariable<float2> copy_devData = new CudaDeviceVariable<float2>(Resolution * Resolution);
    
    int i, j;
    Random rnd = new Random();
    double avrg = 0.0;
    for (i = 0; i < Resolution; i++)
    {
	for (j = 0; j < Resolution; j++)
	{
		fData[(i * Resolution + j)].x = i + j * 2;
		fData[(i * Resolution + j)].y = 0.0f;
	}
    }
			 
    devData.CopyToDevice(fData);
    //Only Resolution times in X and Resolution batches
    CudaFFTPlan1D plan1D = new CudaFFTPlan1D(Resolution, cufftType.C2C, Resolution);
    plan1D.Exec(devData.DevicePointer, TransformDirection.Forward);
    cuKernel.GridDimensions = new ManagedCuda.VectorTypes.dim3(Resolution / 256, Resolution, 1);
    cuKernel.BlockDimensions = new ManagedCuda.VectorTypes.dim3(256, 1, 1);
    cuKernel.Run(devData.DevicePointer, copy_devData.DevicePointer, Resolution);
    devData.CopyToHost(result);
    for (i = 0; i < Resolution; i++)
    {
        for (j = 0; j < Resolution; j++)
        {
            //ResultData[i, j, 0] = result[(i * Resolution + j)].x;
            //ResultData[i, j, 1] = result[(i * Resolution + j)].y;
        }
    }
    //And better free memory using Dispose()
    //ctx.FreeMemory is only meant for raw device pointers obtained from somewhere else...
    devData.Dispose();
    copy_devData.Dispose();
    plan1D.Dispose();
    //For Cuda Memory checker and profiler:
    CudaContext.ProfilerStop();
    ctx.Dispose();
