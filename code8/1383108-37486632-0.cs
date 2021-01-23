    var mockHosp = MockRepository.GenerateMock<IEntity>();
    hospGrp.Stub(x => x.GetEntity(0)).Return(mockHosp);
    mockHosp.Stub(x => x.Id).Return("1");
    
    var hosp_id = MockRepository.GenerateMock<IField>();
    hospGrp.Stub(x => x.GetField("hosp_id")).Return(hosp_id);
    hosp_id.Stub(x => x.Value).Return("Y"); 
           
