     bool MethodWhichDescribesLogic(type aGradeCount, type  bGradeCount, type cGradeCount, type dGradeCount){
        return 
           (PassingGrade(bGradeCount,aGradeCount,cGradeCount) &&
           GoodGradesType(bGradeCount,cGradeCount,dGradeCount,aGradeCount) &&
           dGradeCount <= 3);
        }
      bool PassingGradesCount(type bGradeCount,type aGradeCount,type cGradeCount)
      {
          return bGradeCount >= 3 && aGradeCount <5 && cGradeCount >=2;
      }
      bool GoodGradesCount(type cGradeCount,type bGradeCount,type aGradeCount,type dGradeCount)
      {
          return bGradeCount + cGradeCount +dGradeCount + aGradeCount>= 7;
      }
