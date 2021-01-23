    // a local attribute will 'transport' the data
    ILArray<float> m_data = ILMath.localMember<float>();
    public void UpdateView(ILInArray<float> wfmData) {
        using (ILScope.Enter(wfmData)) {
            m_data.a = wfmData;
            AddWfmToView(); 
        }
    }
    // the actual update method will not expose ILArray parameters. Hence we can use it in a lambda expression.
    void AddWfmToView() {
        if (InvokeRequired) {
            Invoke(new MethodInvoker(() => AddWfmToView()));
        } else {
            // access control here if necessary
            panel.Scene.First<ILLinePlot>().Update(m_data);
            panel.Configure();  
            panel.Refresh(); 
        }
            
    }
