    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing.Imaging;
    using ManagedCuda;
    using ManagedCuda.CudaFFT;
    using ManagedCuda.VectorTypes;
    
    
    namespace WFA_CUDA_FFT
    {
        public partial class CuFFTMain : Form
        {
            float[, ,] FFTData2D;
            int Resolution;
    
            const int cuda_blockNum = 256;
    
            public CuFFTMain()
            {
                InitializeComponent();
                Resolution = 1024;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                cuFFTreconstruct();
            }
            public void cuFFTreconstruct()
            {
                CudaContext ctx = new CudaContext(0);
                ManagedCuda.BasicTypes.CUmodule cumodule = ctx.LoadModule("kernel.ptx");
                CudaKernel cuKernel = new CudaKernel("cu_ArrayInversion", cumodule, ctx);
                float2[] fData = new float2[Resolution * Resolution];
                float2[] result = new float2[Resolution * Resolution];
                FFTData2D = new float[Resolution, Resolution, 2];
                CudaDeviceVariable<float2> devData = new CudaDeviceVariable<float2>(Resolution * Resolution);
                CudaDeviceVariable<float2> copy_devData = new CudaDeviceVariable<float2>(Resolution * Resolution);
    
                int i, j;
                Random rnd = new Random();
                double avrg = 0.0;
    
                for (i = 0; i < Resolution; i++)
                {
                    for (j = 0; j < Resolution; j++)
                    {
                        fData[i * Resolution + j].x = i + j * 2;
                        avrg += fData[i * Resolution + j].x;
                        fData[i * Resolution + j].y = 0.0f;
                    }
                }
    
                avrg = avrg / (double)(Resolution * Resolution);
    
                for (i = 0; i < Resolution; i++)
                {
                    for (j = 0; j < Resolution; j++)
                    {
                        fData[(i * Resolution + j)].x = fData[(i * Resolution + j)].x - (float)avrg;
                    }
                }
    
                devData.CopyToDevice(fData);
    
                CudaFFTPlan1D plan1D = new CudaFFTPlan1D(Resolution, cufftType.C2C, Resolution);
                plan1D.Exec(devData.DevicePointer, TransformDirection.Forward);
    
                cuKernel.GridDimensions = new ManagedCuda.VectorTypes.dim3(Resolution / cuda_blockNum, Resolution, 1);
                cuKernel.BlockDimensions = new ManagedCuda.VectorTypes.dim3(cuda_blockNum, 1, 1);
    
                cuKernel.Run(devData.DevicePointer, copy_devData.DevicePointer, Resolution);
    
                copy_devData.CopyToHost(result);
    
                for (i = 0; i < Resolution; i++)
                {
                    for (j = 0; j < Resolution; j++)
                    {
                        FFTData2D[i, j, 0] = result[i * Resolution + j].x;
                        FFTData2D[i, j, 1] = result[i * Resolution + j].y;
                    }
                }
    
                //Clean up
                devData.Dispose();
                copy_devData.Dispose();
                plan1D.Dispose();
                CudaContext.ProfilerStop();
                ctx.Dispose();
            }
        }
    }
