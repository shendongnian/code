                // If AssumeLocal or AssumeLocal is used, there will always be a kind specified. As in the
                // case when a time zone is present, it will default to being local unless AdjustToUniversal
                // is present. These comparisons determine whether setting the kind is sufficient, or if a
                // time zone adjustment is required. For consistentcy with the rest of parsing, it is desirable
                // to fall through to the Adjust methods below, so that there is consist handling of boundary
                // cases like wrapping around on time-only dates and temporarily allowing an adjusted date
                // to exceed DateTime.MaxValue
                if ((styles & DateTimeStyles.AssumeLocal) != 0) {
                    if ((styles & DateTimeStyles.AdjustToUniversal) != 0) {
                        result.flags |= ParseFlags.TimeZoneUsed;
                        result.timeZoneOffset = TimeZoneInfo.GetLocalUtcOffset(result.parsedDate, TimeZoneInfoOptions.NoThrowOnInvalidTime);
                    }
                    else {
                        result.parsedDate = DateTime.SpecifyKind(result.parsedDate, DateTimeKind.Local);
                        return true;
                    }
                }
                else if ((styles & DateTimeStyles.AssumeUniversal) != 0) {
                    if ((styles & DateTimeStyles.AdjustToUniversal) != 0) {
                        result.parsedDate = DateTime.SpecifyKind(result.parsedDate, DateTimeKind.Utc);
                        return true;
                    }
                    else {
                        result.flags |= ParseFlags.TimeZoneUsed;
                        result.timeZoneOffset = TimeSpan.Zero;
                    }
                }
                else {
                    // No time zone and no Assume flags, so DateTimeKind.Unspecified is fine
                    Contract.Assert(result.parsedDate.Kind == DateTimeKind.Unspecified, "result.parsedDate.Kind == DateTimeKind.Unspecified");
                    return true;
                }
