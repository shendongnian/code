    using (SVM model = new SVM())
                {
                    SVMParams s = new SVMParams();
                    s.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
                    s.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
                    s.C = 1;
                    s.TermCrit = new MCvTermCriteria(100, 0.00001);
    
                    // Lakukan pelatihan
                    model.Train(datalatih, kelas, null, null, s);
                    
                    // Tes Uji SVM
                    for (int i = 0; i < 30; i++)
                    {
                        datauji.Data[0, i] = uji[i];
                    }
                    float hasil = model.Predict(datauji);
                    
                    return Tuple.Create((int)hasil);
                }
