    #import "<aDllFileNAME>"                       // MQL4 pre-processor directive
                            int test_DLL_LOADED(); // DLL  parameter-less signature
                             ...                   //      other signatures of import'd f()
    #import                                        // MQL4 pre-processor directive
    int OnInit(){
        if ( !test_DLL_LOADED() ){
           // FAILED:                              // CLOSE ALL FILE-IOs
                                                   // SEND SIGs / MESSAGEs TO PEERs
                                                   // UPDATE GLOBAL VARIABLEs
                                                   // LOG EVENT
                                                   // GET READY FOR A GRACEFUL EXIT
              ...
           // EXIT:
              ExpertRemove();
        }
     // PASSED: PROCEED WITH A NEXT INTENDED SETUP STEP
        ...
     
    }
