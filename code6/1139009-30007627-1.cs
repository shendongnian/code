    for (var i1 = 0; i1 <= n; i1++)
    {
        for (var i2 = i1 + 1; i2 <= n; i2++)
        {
            for (var i3 = i2 + 1; i3 <= n; i3++)
            {
                ...
                for (var ik = iOneBeforeK + 1; ik <= n; ik++)
                {
                    if (arr[i1] + arr[i2] + ... + arr[ik] == sum)
                    {
                        // this is a valid subset
                    }
                }
            }
        }
    }
