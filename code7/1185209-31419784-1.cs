    double max = RotTab.TabRot(start,i1);
    double maxt = start;
    double cur;
    for(int t=start; t<=end; t+=step){
        cur = RotTab.TabRot(t,i1);
        if(cur > max){
            max = cur;
            maxt = t;
        }
    }
